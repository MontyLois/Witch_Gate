namespace WitchGate.Mission
{
    public class Investigation
    {
        public int CurrentStage { get; private set; }

        public Investigation()
        {
            CurrentStage = 0;
        }

        public void Progress()
        {
            CurrentStage++;
        }
    }
}