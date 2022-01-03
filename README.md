This is a little mod to fix the broken tutorials in 1.12.

The tutorials were broken both by the following changes:

1.  The parts revamp changed the category on the LV-T45 "liquidEngine2" to "none" 
    because of the revamed LV-T45;  they left the old engine to avoid breaking old saves,
    but by changing the category the old engine would be there, but not in the editor.
    Unfortunately, they forgot to update the tutorials which still refer to the old engine

2.  The "Hopper" craft which the tutorials reference isn't showing up because the old vessel
    loading screen apparently had some code to look for the Hopper in a non-standard location.
    I've created a new Hopper to avoid any issue of redistributing Squad assets, it is identical
    to the original, and this patch puts it into the stock vessels.

Packaging and installing

The patch is packaged so that all you have to do is unzip the file into the main KSP directory, the files
will be placed into the correct locations



You can also use CKAN to install this


Note:  This includes bundled copies of the following packages:

    * ModuleManager with it's own license
    * Harmony with it's own license
