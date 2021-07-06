using Marketplace.Framework;

namespace Marketplace.Domain
{
    public class ClassifiedAd: Entity
    {
        public ClassifiedAdId Id { get; }

        public UserId OwnerId { get; }

        public ClassifiedAdTitle Title { get; private set; }

        public ClassifiedAdText Text { get; private set; }

        public Price Price { get; private set; }

        public ClassifiedAdState State { get; private set; }

        public UserId ApprovedBy { get; private set; }

        public ClassifiedAd(ClassifiedAdId id, UserId ownerId)
        {
            Id = id;
            OwnerId = ownerId;
            State = ClassifiedAdState.Inactive;
            EnsureValidState();

            Raise(new Events.ClassifiedAdCreated {
                Id = id,
                OwnerId = ownerId
            });
        }

        public void SetTitle(ClassifiedAdTitle title)
        {
            Title = title;
            EnsureValidState();

            Raise(new Events.ClassifiedAdTitleChanged {
                Id = Id,
                Title = title
            });
        }

        public void UpdateText(ClassifiedAdText text)
        {
            Text = text;
            EnsureValidState();
        }

        public void UpdatePrice(Price price)
        {
            Price = price;
            EnsureValidState();
        }

        public void RequestToPublish()
        {
            if (Title == null)
            {
                throw new InvalidEntityStateException(this, "title cannot be empty");
            }

            if (Text == null)
            {
                throw new InvalidEntityStateException(this, "text cannot be empty");
            }

            if (Price?.Amount == 0)
            {
                throw new InvalidEntityStateException(this, "price cannot be zero");
            }

            State = ClassifiedAdState.PendingReview;
            EnsureValidState();
        }

        public enum ClassifiedAdState
        {
            PendingReview,
            Active,
            Inactive,
            MarkedAsSold
        }

        private void EnsureValidState()
        {
            var valid = Id != null && OwnerId != null &&
            (State switch
            {
                ClassifiedAdState.PendingReview =>
                    Title != null && Text != null && Price?.Amount > 0,
                ClassifiedAdState.Active =>
                    Title != null && Text != null && Price?.Amount > 0 && ApprovedBy != null,
                _ => true
            });

            if (!valid) {
                throw new InvalidEntityStateException(this, $"Post-checks failed in state {State}");
            }
        }
    }
}
