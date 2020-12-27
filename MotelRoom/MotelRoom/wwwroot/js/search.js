$(document).ready(function () {
    var obj = new ClientScreenJS();


})

class ClientScreenJS {
    constructor() {
        this.initEvents();
    }

    initEvents() {
        //$('#btnSearch').click(this.btnSearchOnClick.bind(this));
        $('#province').change(this.provinceChange.bind(this));
        $('#district').change(this.districtChange.bind(this));
    }
    provinceChange() {
        var url = '/' + "Home/GetDistrictList";
        $.getJSON(url, { idProvince: $('#province').val() }, function (data) {
            var items = "<option value=''>Huyện/Quận</option>";
            $('#district').empty();
            //debugger;
            $.each(data, function (i, districtlist) {
                items += "<option value='" + districtlist.Value + "'>" + districtlist.Text + "</option>";
            })
            $('#district').html(items);
            //debugger;
        });
    }
    districtChange() {
        var urlWard = '/' + "Home/GetWardList";
        var urlStreet = '/' + "Home/GetStreetList";
        $.getJSON(urlWard, { idDistrict: $('#district').val() }, function (data) {
            var items = '';
            //debugger;
            $('#ward').empty();
            $.each(data, function (i, wardList) {
                items += "<option value='" + wardList.Value + "'>" + wardList.Text + "</option>";
            })
            $('#ward').html(items);
        });

        $.getJSON(urlStreet, { idDistrict: $('#district').val() }, function (data) {
            var items = '';
            $('#street').empty();
            $.each(data, function (i, streetList) {
                items += "<option value='" + streetList.Value + "'>" + streetList.Text + "</option>";
            })
            $('#street').html(items);
        });
    }
    btnSearchOnClick() {
        var area = $('#area').val().split(',');
        var objSearchRoom = {}
        objSearchRoom.publicPlaceAround = $('#publicPlaceAround').val();
        objSearchRoom.idProvince = $('#province').val();
        objSearchRoom.idDistrict = $('#district').val();
        objSearchRoom.idWard = $('#ward').val();
        objSearchRoom.idStreet = $('#street').val();
        objSearchRoom.priceMin = $('#priceMin').val();
        objSearchRoom.priceMax = $('#priceMax').val();
        objSearchRoom.typeRoom = $('#typeRoom').val();
        objSearchRoom.areaMin = area[0];
        objSearchRoom.areaMax = area[1];
        objSearchRoom.bathroom = $('#bathroom').val();
        objSearchRoom.heater = $('#heater').val();
        objSearchRoom.kitchen = $('#kitchen').val();
        objSearchRoom.airCondition = $('#airCondition').val();
        objSearchRoom.balcony = $('#balcony').val();
        var content = JSON.stringify(objSearchRoom); // chuyen doi tuong sang json
        //debugger;
        $.ajax({
            url: "/Home/SearchClientScreen",
            method: "POST",
            data: content,
            contentType: "application/json",
            dataType: "json"
        }).done(function (data) {
            window.location.href = '@Url.Action("SearchClientScreen", "Home")';
            //debugger;
        }).fail(function (data) {
            //debugger;
        })
    }
}
function updatePriceInput(val) {
    debugger;
    var str = " " + val + " ";
    $('#textPrice').value = val;
}