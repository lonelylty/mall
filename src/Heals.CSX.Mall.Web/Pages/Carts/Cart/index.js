$(function () {

    var l = abp.localization.getResource('Mall');

    var service = heals.cSX.mall.carts.cart;
    var createModal = new abp.ModalManager(abp.appPath + 'Carts/Cart/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Carts/Cart/EditModal');

    var dataTable = $('#CartTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('Mall.Cart.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Mall.Cart.Delete'),
                                confirmMessage: function (data) {
                                    return l('CartDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            { data: "buyerId" },
            { data: "items" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewCartButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
