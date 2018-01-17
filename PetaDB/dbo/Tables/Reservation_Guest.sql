CREATE TABLE [dbo].[Reservation_Guest]
(
	[ReservationID] INT NOT NULL , 
    [GuestID] INT NOT NULL, 
    [IsLead] BIT NULL, 
    CONSTRAINT [FK_Reservation_Guest_Reservation] FOREIGN KEY ([ReservationID]) REFERENCES [Reservation]([ReservationID]), 
    CONSTRAINT [FK_Reservation_Guest_Guest] FOREIGN KEY ([GuestID]) REFERENCES [Guests]([GuestID])
)
