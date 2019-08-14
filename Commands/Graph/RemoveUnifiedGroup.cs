﻿using OfficeDevPnP.Core.Entities;
using OfficeDevPnP.Core.Framework.Graph;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Remove, "PnPUnifiedGroup")]
    [CmdletHelp("Removes one Office 365 Group (aka Unified Group)",
        Category = CmdletHelpCategory.Graph,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Remove-PnPUnifiedGroup -Identity $groupId",
       Remarks = "Removes an Office 365 Group based on its ID",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Remove-PnPUnifiedGroup -Identity $group",
       Remarks = "Removes the provided Office 365 Group",
       SortOrder = 2)]
    [CmdletExample(
       Code = "PS:> Get-PnPUnifiedGroup | ? Visibility -eq \"Public\" | Remove-PnPUnifiedGroup",
       Remarks = "Removes all the public Office 365 Groups",
       SortOrder = 3)]
    public class RemoveUnifiedGroup : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Identity of the Office 365 Group")]
        public UnifiedGroupPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            if (Identity != null)
            {
                UnifiedGroupEntity group = Identity.GetGroup(AccessToken);
                
                if (group != null)
                {
                    UnifiedGroupsUtility.DeleteUnifiedGroup(group.GroupId, AccessToken);
                }
            }
        }
    }
}
