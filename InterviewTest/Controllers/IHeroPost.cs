namespace InterviewTest.Controllers
{
    public interface IHeroPost 
    {
        IHero Hero { get; set; }
        Action action { get; set; }
    }
}