$(function () {

    var l = abp.localization.getResource('Mall');

    var service = heals.cSX.mall.addresses.address;
    var createModal = new abp.ModalManager(abp.appPath + 'Addresses/Address/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Addresses/Address/EditModal');

    var dataTable = $('#AddressTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Mall.Address.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Mall.Address.Delete'),
                                confirmMessage: function (data) {
                                    return l('AddressDeletionConfirmationMessage', data.record.id);
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
            { data: "clinicCode" },
            { data: "clinicName" },
            { data: "contacts" },
            { data: "phone" },
            { data: "customerName" },
            { data: "customerAccount" },
            { data: "remarks" },
            { data: "healsRemarks" },
            { data: "street" },
            { data: "city" },
            { data: "state" },
            { data: "country" },
            { data: "zipCode" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewAddressButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
