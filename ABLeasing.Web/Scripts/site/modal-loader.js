function showModal(modalContainerId, modalBodyId, id) {
    var url = $(modalContainerId).data('url');

    $.get(url, { id: id }, function (data) {
        $(modalBodyId).html(data);
        $(modalContainerId).modal('show');
    });
}