using DesignPattern.Patterns.BehavioralPatterns;

namespace DesignPattern.Client;

public class ObserverClient: IAbstractClient
{
    public void Execute()
    {
        Subject newspaperAgency = new Subject();
        
        SportFans fansA = new SportFans("David");
        SportFans fansB = new SportFans("John");
        newspaperAgency.Attach(fansA, EventType.SportEvent);
        newspaperAgency.Attach(fansB, EventType.SportEvent);
        
        TechFans fansC = new TechFans("Elon");
        TechFans fansD = new TechFans("Max");
        newspaperAgency.Attach(fansC, EventType.TechEvent);
        newspaperAgency.Attach(fansD, EventType.TechEvent);
        
        newspaperAgency.ProcessDailyEvent();
    }
}