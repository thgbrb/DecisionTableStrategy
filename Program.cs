using System;

namespace DecisionTable
{
    class Program
    {
        static void Main(string[] args)
        { }
    }

    class Appointment
    {
        private const bool F = false;
        private const bool T = true;

        public readonly bool IsAllDay;
        public readonly bool IsRecurrent;
        public readonly bool HasConflict;
        public readonly bool HasAdjactentMeeting;
        public readonly bool IsSafityMinimalDuraton;
        public readonly bool IsSatifyMinimalParticipantNumber;
        public readonly bool IsEvent;

        public bool Decide() =>
            (IsAllDay, IsRecurrent, HasConflict, HasAdjactentMeeting, IsSafityMinimalDuraton, IsSatifyMinimalParticipantNumber, IsEvent) switch
            {
                (T, _, _, _, _, _, _) => DeclineMeeting(),
                (_, T, _, _, _, _, _) => DeclineMeeting(),
                (F, F, T, _, _, _, _) => DeclineMeeting(),
                (F, F, F, _, F, _, _) => DeclineMeeting(),
                (F, F, F, _, T, F, _) when!IsEvent => DeclineMeeting(),
                (F, F, F, _, T, T, _) => AccepMeeting(),
                (F, F, F, _, T, _, T) => AccepMeeting(),
                _ => DeclineMeeting()
            };

        static bool AccepMeeting() =>
            throw new NotImplementedException();

        static bool DeclineMeeting() =>
            throw new NotImplementedException();

        public void Deconstruct(out bool isAllDay, out bool isRecurrent, out bool hasConflict, out bool hasAdjactentMeeting, out bool isSafityMinimalDuraton, out bool isSatifyMinimalParticipantNumber, out bool isEvent)
        {
            isAllDay = IsAllDay;
            isRecurrent = IsRecurrent;
            hasConflict = HasConflict;
            hasAdjactentMeeting = HasAdjactentMeeting;
            isSafityMinimalDuraton = IsSafityMinimalDuraton;
            isSatifyMinimalParticipantNumber = IsSatifyMinimalParticipantNumber;
            isEvent = IsEvent;
        }
    }
}