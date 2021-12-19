namespace InterviewTest.Controllers
{
    public class HeroPost : IHeroPost
    {
        public IHero Hero { get; set; }
        public Action action { get; set; }
    }
}
