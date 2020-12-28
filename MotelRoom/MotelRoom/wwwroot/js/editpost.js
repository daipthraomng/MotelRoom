
$(document).ready(function () {
    var obj = new EditPostJS();
})

class EditPostJS {
    constructor() {
        this.initEvents();
    }

    initEvents() {
        $('#province').change(this.provinceChange.bind(this));
        $('#district').change(this.districtChange.bind(this));
        $('#timeDisplay').change(this.timeDisplayChange.bind(this));
        $('#unitTimeId').change(this.timeDisplayChange.bind(this));
    }
    timeDisplayChange() {
        var timeDisplay = $('#timeDisplay').val();
        var unitTimeId = $('#unitTimeId').val();
        var priceUOT = 1;
        switch (unitTimeId) {
            case "1":
                priceUOT = 5000;
                break;
            case "2":
                priceUOT = 30000;
                break
            case "3":
                priceUOT = 100000;
                break;
            case "4":
                priceUOT = 500000;
                break;
        }
        var pricePost = timeDisplay * priceUOT;
        //debugger;
        document.getElementById("pricePost").value = pricePost;
    }
    provinceChange() {
        var url = '/' + "Home/GetDistrictList";
        $.getJSON(url, { idProvince: $('#province').val() }, function (data) {
            var items = "<option value='0'>Select One</option>";
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
    
}
function btnEditOnClick(idRoom) {
    var objPostNews = {}
    objPostNews.idRoom = idRoom;
    objPostNews.title = $('#title').val();
    objPostNews.idProvince = $('#province').val();
    objPostNews.idDistrict = $('#district').val();
    objPostNews.idWard = $('#ward').val();
    objPostNews.idStreet = $('#street').val();
    objPostNews.homeNo = $('#homeNo').val();
    objPostNews.publicPlaceAround = $('#publicPlaceAround').val();
    objPostNews.typeRoom = $('#typeRoom').val();
    objPostNews.roomNo = $('#roomNo').val();
    objPostNews.price = $('#price').val();
    objPostNews.area = $('#area').val();
    objPostNews.bathroom = $('#bathroom').val();
    objPostNews.heater = $('#heater').val();
    objPostNews.kitchen = $('#kitchen').val();
    objPostNews.airCondition = $('#airCondition').val();
    objPostNews.balcony = $('#balcony').val();
    objPostNews.electricityPrice = $('#electricityPrice').val();
    objPostNews.waterPrice = $('#waterPrice').val();
    objPostNews.otherUtility = $('#otherUtility').val();
    objPostNews.description = $('#description').val();
    objPostNews.nameBoss = $('#nameBoss').val();
    objPostNews.phoneBoss = $('#phoneBoss').val();
    objPostNews.timeDisplay = $('#timeDisplay').val();
    objPostNews.unitTimeId = $('#unitTimeId').val();
    var content = JSON.stringify(objPostNews); // chuyen doi tuong sang json
    //debugger;
    $.ajax({
        url: "/Home/PendingMotel",
        method: "POST",
        data: content,
        contentType: "application/json",
        dataType: "json"
    }).done(function (res) {
        alert("Đăng bài thành công");
        //debugger;
    }).fail(function (res) {
        //debugger;
    })
}
function btnCancelOnClick(idRoom) {
    var url = '/' + "Home/CancelPost";
    //debugger;
    $.getJSON(url, { idRoom: idRoom }, function (data) {
        console.log(data);
        alert("Hủy bài viết thành công");
        //debugger;
    });
}