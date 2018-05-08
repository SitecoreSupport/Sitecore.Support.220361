using Sitecore.ContentSearch;
using Sitecore.Data;
using Sitecore.Data.Managers;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.ContentSearch
{
  public class SitecoreItemCrawler : Sitecore.ContentSearch.SitecoreItemCrawler
  {
    public SitecoreItemCrawler()
    {
    }
    public override void Update(IProviderUpdateContext context, IIndexableUniqueId indexableUniqueId, IndexEntryOperationContext operationContext, IndexingOptions indexingOptions = 0)
    {
      base.Update(context, indexableUniqueId, operationContext, indexingOptions);
      ItemUri itemUri = indexableUniqueId as SitecoreItemUniqueId;
      ItemUri itemUriFirstVersion = new ItemUri(itemUri.ItemID, itemUri.Language, Data.Version.First, itemUri.DatabaseName);
      SitecoreItemUniqueId indexableUniqueIdFirstVersion = new SitecoreItemUniqueId(itemUriFirstVersion);
      if (context.Index.EnableItemLanguageFallback)
      {
        base.Update(context, indexableUniqueIdFirstVersion, operationContext, indexingOptions);
      }
    }
  }
}