using IndependentTablespace.Samples.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace IndependentTablespace.Samples.Permissions;

public class SamplesPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var SamplesGroup = context.AddGroup(SamplesPermissions.GroupName, L("Permission:Samples"));

        var booksPermission = SamplesGroup.AddPermission(SamplesPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(SamplesPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(SamplesPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(SamplesPermissions.Books.Delete, L("Permission:Books.Delete"));

        var authorsPermission = SamplesGroup.AddPermission(
            SamplesPermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(
            SamplesPermissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(
            SamplesPermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(
            SamplesPermissions.Authors.Delete, L("Permission:Authors.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SamplesResource>(name);
    }
}
