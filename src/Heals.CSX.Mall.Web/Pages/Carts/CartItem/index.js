$(function () {

    var l = abp.localization.getResource('Mall');

    var service = heals.cSX.mall.carts.cartItem;
    var createModal = new abp.ModalManager(abp.appPath + 'Carts/CartItem/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Carts/CartItem/EditModal');

    var dataTable = $('#CartItemTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Mall.CartItem.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Mall.CartItem.Delete'),
                                confirmMessage: function (data) {
                                    return l('CartItemDeletionConfirmationMessage', data.record.id);
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
            { data: "unitPrice" },
            { data: "quantity" },
            { data: "productId" },
            { data: "product" },
            { data: "cartId" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewCartItemButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
