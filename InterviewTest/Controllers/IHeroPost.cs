namespace InterviewTest.Controllers
{
    public interface IHeroPost 
    {
        IHero hero { get; set; }
        Action action { get; set; }
    }
}