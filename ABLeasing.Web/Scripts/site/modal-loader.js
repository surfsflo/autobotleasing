
function openModal(evt) {
    var $obj = $(evt.target);
    var actionModal = $obj.data('modalid');
    $actionModal = $('#'+actionModal);
    var url = $obj.data('url');

    $actionModal.empty();
    $actionModal.load(url, function () {
        $('.modal', $actionModal).modal('show');
    });
}