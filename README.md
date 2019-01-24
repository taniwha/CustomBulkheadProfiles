# Custom Bulkhead Profiles
Custom Bulkhead Profiles is a Kerbal Space Program mod to set icons and
tooltips for custom bulkhead profiles.

KSP has provided part filters for some time now, including the ability
to filter parts based on their "bulkhead profiles": essentially their
size and shape. However, KSP determines a part's profiles simply by tags
defined in the part's configuration, with minimal support for custom
profiles: the part would be sorted correctly, but the filter buttons
would have a question mark icon and no tooltip, leaving it up to modders
to find a way to set the icon and tooltip. Custom Bulkhead Profiles is a
mod that makes it easy for non-programmers to configure custom profiles
and also eliminates the need for every mod to provide its own
customization code.

## Defining a custom bulkhead profile
Defining a custom bulkhead profile is very simple: create a KSP config
file with a BulkheadProfileDefinition that gives the profile name,
display name (used for the tooltip) and the normal and selected icon
texture paths. eg

```
BulkheadProfileDefinition {
    name = dgsize1
	displayName = DG 1 [1.875m]
	normalIcon = DiamondGrid/Textures/size1
	selectedIcon = DiamondGrid/Textures/size1
}
```
