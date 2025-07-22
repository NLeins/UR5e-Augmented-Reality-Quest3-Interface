public class GripperAction
{
    public bool Open { get; set; }
    public int ProgramStepIndex { get; set; }

    public GripperAction(bool open, int programStepIndex)
    {
        Open = open;
        ProgramStepIndex = programStepIndex;
    }
}
