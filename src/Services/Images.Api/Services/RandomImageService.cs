namespace Images.Api.Services;

public class RandomImageService : IRandomImageService
{

    private List<string> _randomImageUrls = new List<string>()
        {
            "https://randompicturegenerator.com/img/national-park-generator/gb172f49435f88e6a1bdbad656dbbe47fe1065a60eeebfc3603ab04037718c60bb8f037d4191efa23ab63da0c4c2e26d6_640.jpg",
            "https://randompicturegenerator.com/img/national-park-generator/ga0407435c9eb832f82caf1c54c96e5598a7c12fde4f01b67e460a7137db92186bdf2ff36d2b95bfbdf4851a0f21890ec_640.jpg",
            "https://randompicturegenerator.com/img/national-park-generator/g1508dff88fc5278782df3bcd4837e0cf2c9ff965134666060276a7545a029625573f6d44d30b11b2a5984bee76914253_640.jpg",
            "https://randompicturegenerator.com/img/national-park-generator/g6eb6459cb71383e5f2b494eff3b969ad31e8656a3316fc14b213d4bbf663973f745250707b8168ac446903d46a644ce0_640.jpg",
            "https://randompicturegenerator.com/img/national-park-generator/g2256ed014716a4292d6a2d17c3b836e19b0344f28e7d0fd30baa62ebc1add316e179a771c958925ededb233d310024b6_640.jpg",
            "https://randompicturegenerator.com/img/national-park-generator/gca0d3064a837b1f03550658a44aa1a0054c1da3ad0f423377380f1920f2a2362bc5e5a9fb8b5b7bf2fe0e970cf532570_640.jpg",
            "https://randompicturegenerator.com/img/national-park-generator/g2f9370f6980dfc3792c38ec2768e0433fa02fb58aa64d5e492f1da3479d5fc0b9d8e2c5982fdc70e5241777c16855ccd_640.jpg",
            "https://randompicturegenerator.com/img/national-park-generator/ga6865aa07f894f2e963632242ed55cfa95eea9dbea4938195fb281d639d8a6a9463d9bae0205b71df95f4bb2addec5f4_640.jpg",
            "https://randompicturegenerator.com/img/national-park-generator/g005c88eff44ad1c5c8fac27f321ab925d8e9f323b298e29f7913eee8d3f391e8a90aa7baed7144f1be9828fa863af1d8_640.jpg",
            "https://randompicturegenerator.com/img/national-park-generator/gc73b8dfc76bd4060240b527ee22a5e7b32e8014749a93d6555d770754e2662d4a8e212a62a4b09a940921dbbb4f14739_640.jpg",
            "https://randompicturegenerator.com/img/national-park-generator/gb35af25189a2a6acb76d10404a56da9b3b2aeca1def429e1d76ce57fe92bedda4228ece0725c7779076a1a3a52277395_640.jpg",
        };
    public string GetRandomImageUrl()
        => _randomImageUrls[new Random().Next(0, _randomImageUrls.Count)];
}