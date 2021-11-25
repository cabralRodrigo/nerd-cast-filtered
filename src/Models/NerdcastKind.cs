using System.ComponentModel;

namespace JovemNerd.Rss.Filter.Models
{
    public enum NerdcastKind
    {
        [Description("NerdCast")]
        NerdCast,

        [Description("Caneca de Mamicas")]
        CanecaMamicas,

        [Description("Speak English")]
        SpeakEnglish,

        [Description("Empreendedor")]
        Empreendedor,

        [Description("NerdCash")]
        NerdCash,

        [Description("NerdTech")]
        NerdTech,

        [Description("Papo de Parceiro")]
        PapoParceiro,

        [Description("Lá do Bunker")]
        Bunker,

        [Description("Generacast")]
        Generacast,

        [Description("Outros")]
        Outros
    }
}