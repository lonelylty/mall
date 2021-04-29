$(function () {

    var l = abp.localization.getResource('Mall');

    var service = heals.cSX.mall.products.product;
    var createModal = new abp.ModalManager(abp.appPath + 'Products/Product/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Products/Product/EditModal');

    var dataTable = $('#ProductTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Mall.Product.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Mall.Product.Delete'),
                                confirmMessage: function (data) {
                                    return l('ProductDeletionConfirmationMessage', data.record.id);
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
            { data: "clinicId" },
            { data: "clinicCode" },
            { data: "name" },
            { data: "productID" },
            { data: "serialNumber" },
            { data: "description" },
            { data: "pictureUri" },
            { data: "specification" },
            { data: "supplierName" },
            { data: "unit" },
            { data: "unitPrice" },
            { data: "sRP" },
            { data: "color" },
            { data: "stockLevel" },
            { data: "bundled" },
            { data: "catalogTypeId" },
            { data: "catalogType" },
            { data: "catalogBrand" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewProductButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
