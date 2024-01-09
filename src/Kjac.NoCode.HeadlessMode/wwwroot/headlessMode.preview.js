angular.module('umbraco').config(['$provide', $provide => {
  $provide.decorator("$rootScope",
    function headlessModePreview($delegate) {

      $delegate.$on('content.loaded', (evt, data) => {
        onLoad();
      });
      $delegate.$on('content.saved', (evt, data) => {
        onLoad();
      });

      function onLoad() {
        const lookForPreviewButtonInterval = setInterval(function () {
          const group = document.querySelector('div[sub-buttons="previewSubButtons"]');
          if(!group){
            return;
          }

          clearInterval(lookForPreviewButtonInterval);

          const defaultButton = group.querySelector('umb-button[alias="preview"] button');
          const defaultButtonContent = defaultButton?.querySelector('.umb-button__content');
          const toggle = group.querySelector('button[data-element="button-group-toggle"]');

          if (defaultButton && !toggle) {
            // no additional preview URLs defined, hide the entire group
            // - ideally this should be set in CSS, but it seems we can't apply complex selectors to :not()
            group.style.display = "none";
            return;
          }

          if (defaultButton && defaultButtonContent && toggle) {
            defaultButtonContent.onclick = function (evt) {
              evt.stopImmediatePropagation();
              evt.preventDefault();

              group.classList.add("-hide-preview-sub-buttons");
              toggle.click();

              const lookForPreviewSubButtons = setInterval(function () {
                const subButtons = group.querySelectorAll('ul li button');
                if (!subButtons.length) {
                  return;
                }

                clearInterval(lookForPreviewSubButtons);

                subButtons[0].click();
                group.classList.remove("-hide-preview-sub-buttons");
              }, 20);
            };
          }
        }, 50);
      }

      return $delegate;
    });
}]);
