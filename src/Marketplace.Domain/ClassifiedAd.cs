﻿using System;

namespace Marketplace.Domain
{
    public class ClassifiedAd
    {
        public ClassifiedAdId Id { get; }

        public ClassifiedAdTitle Title { get; private set; }

        public ClassifiedAdText Text { get; private set; }

        public Price Price { get; private set; }

        public UserId OwnerId { get; }
        public ClassifiedAdState State { get; private set; }

        public ClassifiedAd(ClassifiedAdId id, UserId ownerId)
        {
            Id = id;
            OwnerId = ownerId;
            State = ClassifiedAdState.Inactive;
        }

        public void SetTitle(ClassifiedAdTitle title) => Title = title;

        public void UpdateText(ClassifiedAdText text) => Text = text;

        public void UpdatePrice(Price price) => Price = price;

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
        }

        public enum ClassifiedAdState {
            PendingReview,
            Active,
            Inactive,
            MarkedAsSold
        }
    }
}
