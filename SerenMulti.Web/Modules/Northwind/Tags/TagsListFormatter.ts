namespace SerenMulti.Northwind
{
    @Serenity.Decorators.registerFormatter()
    export class TagsListFormatter implements Slick.Formatter {
        format(ctx: Slick.FormatterContext) {
            var isi = ctx.value as string;
            if (!isi)
                return "";

            var dt = isi.split(",");
            var idList = dt as string[];
            if (!idList || !idList.length)
                return "";

            var byId = TagsRow.getLookup().itemById;
            let z: TagsRow;
            return idList.map(x => ((z = byId[x]) ? "<a href='javascript:;' class='tag-link'>" + z.Name + "</a>" : x)).join(", ");
        }
    }
}
