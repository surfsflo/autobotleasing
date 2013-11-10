

   ----------------------------------------------------------------------
          README file for Bundle Transformer: Sass and SCSS 1.8.9

   ----------------------------------------------------------------------

          Copyright 2013 Andrey Taritsyn - http://www.taritsyn.ru
		  

   ===========
   DESCRIPTION
   ===========
   BundleTransformer.SassAndScss contains translator-adapter 
   `SassAndScssTranslator` (supports Sass (http://sass-lang.com) 
   version 3.2.12). This adapter makes translation of Sass- and 
   SCSS-code to CSS-code.
   Also contains debugging HTTP-handler `SassAndScssAssetHandler`, which 
   is responsible for text output of translated Sass- or SCSS-asset.
   
   =============
   RELEASE NOTES
   =============
   Fixed minor bugs.
   
   ====================
   POST-INSTALL ACTIONS
   ====================
   To use a debugging HTTP-handlers in the IIS Classic mode, you need add
   to the `/configuration/system.web/httpHandlers` element of the 
   Web.config file a following code:
   
   <add
	path="*.sass" verb="GET"
	type="BundleTransformer.SassAndScss.HttpHandlers.SassAndScssAssetHandler, BundleTransformer.SassAndScss" />
   <add
	path="*.scss" verb="GET"
	type="BundleTransformer.SassAndScss.HttpHandlers.SassAndScssAssetHandler, BundleTransformer.SassAndScss" />
   
   =============
   DOCUMENTATION
   =============
   See documentation on CodePlex - 
   http://bundletransformer.codeplex.com/documentation