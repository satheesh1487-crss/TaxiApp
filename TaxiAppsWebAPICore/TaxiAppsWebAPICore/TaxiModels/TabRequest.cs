using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabRequest
    {
        public TabRequest()
        {
            TabCancellationFeeForDriver = new HashSet<TabCancellationFeeForDriver>();
            TabRequestMeta = new HashSet<TabRequestMeta>();
            TabRequestPlace = new HashSet<TabRequestPlace>();
        }

        public long Id { get; set; }
        public string RequestId { get; set; }
        public int? RequestOtp { get; set; }
        public int Later { get; set; }
        public long? UserId { get; set; }
        public long? DriverId { get; set; }
        public int? IsShare { get; set; }
        public int? NoOfSeats { get; set; }
        public DateTime? TripStartTime { get; set; }
        public string IsDriverStarted { get; set; }
        public string IsDriverArrived { get; set; }
        public string IsTripStart { get; set; }
        public string IsCompleted { get; set; }
        public string IsCancelled { get; set; }
        public string Reason { get; set; }
        public string CancelOtherReason { get; set; }
        public string CancelMethod { get; set; }
        public decimal? Distance { get; set; }
        public decimal? WaitingTime { get; set; }
        public decimal? Time { get; set; }
        public double? Total { get; set; }
        public string PaymentOpt { get; set; }
        public string IsPaid { get; set; }
        public int? UserRated { get; set; }
        public int? DriverRated { get; set; }
        public string PaymentId { get; set; }
        public long? CardId { get; set; }
        public long? Typeid { get; set; }
        public long? PromoId { get; set; }
        public string Timezone { get; set; }
        public int? Unit { get; set; }
        public int? IfDispatch { get; set; }
        public string DispatchReference { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? SubscribedDriverAcceptRequest { get; set; }
        public int? RideLaterCustomDriver { get; set; }
        public int? RideLaterCustomAcceptedDriverId { get; set; }
        public DateTime? DriverAcceptedTime { get; set; }
        public int? FreeWaitingTime { get; set; }
        public string InstantTrip { get; set; }
        public string Isreschedule { get; set; }
        public DateTime? ShowCancelButtonToDriverAtTime { get; set; }
        public DateTime? ScheduleAtTime { get; set; }
        public int? CancelDialogBoxAfterWaitingTime { get; set; }
        public DateTime? CancelDialogBoxClickedTime { get; set; }
        public DateTime? TripEndTime { get; set; }
        public int? FixedPlaceId { get; set; }

        public virtual TabDrivers Driver { get; set; }
        public virtual TabTypes Type { get; set; }
        public virtual TabUser User { get; set; }
        public virtual ICollection<TabCancellationFeeForDriver> TabCancellationFeeForDriver { get; set; }
        public virtual ICollection<TabRequestMeta> TabRequestMeta { get; set; }
        public virtual ICollection<TabRequestPlace> TabRequestPlace { get; set; }
    }
}
