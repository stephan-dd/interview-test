namespace InterviewTest.Controllers
{
    public class HeroPost : IHeroPost
    {
        public IHero hero { get; set; } = new Hero();
        public Action action { get; set; }
    }
}
