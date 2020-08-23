using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_request")]
    public partial class TabRequest
    {
        public TabRequest()
        {
            TabCancellationFeeForDriver = new HashSet<TabCancellationFeeForDriver>();
            TabRequestMeta = new HashSet<TabRequestMeta>();
            TabRequestPlace = new HashSet<TabRequestPlace>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("Request_id")]
        [StringLength(300)]
        public string RequestId { get; set; }
        [Column("request_otp")]
        public int? RequestOtp { get; set; }
        [Column("later")]
        public int Later { get; set; }
        [Column("user_id")]
        public long? UserId { get; set; }
        [Column("driver_id")]
        public long? DriverId { get; set; }
        [Column("is_share")]
        public int? IsShare { get; set; }
        [Column("no_of_seats")]
        public int? NoOfSeats { get; set; }
        [Column("trip_start_time", TypeName = "datetime")]
        public DateTime? TripStartTime { get; set; }
        [Column("is_driver_started")]
        [StringLength(10)]
        public string IsDriverStarted { get; set; }
        [Column("is_driver_arrived")]
        [StringLength(100)]
        public string IsDriverArrived { get; set; }
        [Column("is_trip_start")]
        [StringLength(100)]
        public string IsTripStart { get; set; }
        [Column("is_completed")]
        [StringLength(100)]
        public string IsCompleted { get; set; }
        [Column("is_cancelled")]
        [StringLength(100)]
        public string IsCancelled { get; set; }
        [Column("reason")]
        [StringLength(200)]
        public string Reason { get; set; }
        [Column("cancel_other_reason")]
        [StringLength(200)]
        public string CancelOtherReason { get; set; }
        [Column("cancel_method")]
        [StringLength(50)]
        public string CancelMethod { get; set; }
        [Column("distance", TypeName = "decimal(10, 2)")]
        public decimal? Distance { get; set; }
        [Column("waiting_time", TypeName = "decimal(10, 2)")]
        public decimal? WaitingTime { get; set; }
        [Column("time", TypeName = "decimal(10, 2)")]
        public decimal? Time { get; set; }
        [Column("total")]
        public double? Total { get; set; }
        [Column("payment_opt")]
        [StringLength(50)]
        public string PaymentOpt { get; set; }
        [Column("is_paid")]
        [StringLength(50)]
        public string IsPaid { get; set; }
        [Column("user_rated")]
        public int? UserRated { get; set; }
        [Column("driver_rated")]
        public int? DriverRated { get; set; }
        [Column("payment_id")]
        [StringLength(100)]
        public string PaymentId { get; set; }
        [Column("card_id")]
        public long? CardId { get; set; }
        [Column("typeid")]
        public long? Typeid { get; set; }
        [Column("promo_id")]
        public long? PromoId { get; set; }
        [Column("timezone")]
        [StringLength(100)]
        public string Timezone { get; set; }
        [Column("unit")]
        public int? Unit { get; set; }
        [Column("if_dispatch")]
        public int? IfDispatch { get; set; }
        [Column("dispatch_reference")]
        [StringLength(400)]
        public string DispatchReference { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }
        [Column("subscribed_driver_accept_request")]
        public int? SubscribedDriverAcceptRequest { get; set; }
        [Column("ride_later_custom_driver")]
        public int? RideLaterCustomDriver { get; set; }
        [Column("ride_later_custom_accepted_driver_id")]
        public int? RideLaterCustomAcceptedDriverId { get; set; }
        [Column("driver_accepted_time", TypeName = "datetime")]
        public DateTime? DriverAcceptedTime { get; set; }
        [Column("free_waiting_time")]
        public int? FreeWaitingTime { get; set; }
        [Column("instant_trip")]
        [StringLength(100)]
        public string InstantTrip { get; set; }
        [StringLength(10)]
        public string Isreschedule { get; set; }
        [Column("show_cancel_button_to_driver_at_time", TypeName = "datetime")]
        public DateTime? ShowCancelButtonToDriverAtTime { get; set; }
        [Column("schedule_at_time", TypeName = "datetime")]
        public DateTime? ScheduleAtTime { get; set; }
        [Column("cancel_dialog_box_after_waiting_time")]
        public int? CancelDialogBoxAfterWaitingTime { get; set; }
        [Column("cancel_dialog_box_clicked_time", TypeName = "datetime")]
        public DateTime? CancelDialogBoxClickedTime { get; set; }
        [Column("trip_end_time", TypeName = "datetime")]
        public DateTime? TripEndTime { get; set; }
        [Column("fixed_place_id")]
        public int? FixedPlaceId { get; set; }

        [ForeignKey(nameof(DriverId))]
        [InverseProperty(nameof(TabDrivers.TabRequest))]
        public virtual TabDrivers Driver { get; set; }
        [ForeignKey(nameof(Typeid))]
        [InverseProperty(nameof(TabTypes.TabRequest))]
        public virtual TabTypes Type { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(TabUser.TabRequest))]
        public virtual TabUser User { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<TabCancellationFeeForDriver> TabCancellationFeeForDriver { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<TabRequestMeta> TabRequestMeta { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<TabRequestPlace> TabRequestPlace { get; set; }
    }
}
