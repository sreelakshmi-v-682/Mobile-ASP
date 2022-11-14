$(document).ready(function () {
	alert("hello");
	$("#txtFile").change(function (event) {
		var files = event.target.files;
		$("imgView").attr("src", window.URL.createObjectURL(files[0]));
	});
	$("btnSave").click(function () {
		var files = $("#txtFile").prop("files");
		var formData = new FormData();
		for (var i = 0; i < files.Length; i++) {
			formData.append("file", files[i]);
		}
		var oMobile = {
			Name: $("txtName").val(),
			Name: $("txtCat").val(),

		};
		formData.append("mobile", JSON.stringify(oMobile));
		$.ajax({
			type: "POST",
			url: "/Home/SaveFile",
			data: formData,
			processData: false,
			contentType: false,
			success: function (data) {
				ResetFields();
				alert(data);
			},
			error: function (data) {
				console.log('Error:', data);
			}

		});
	});
	$("btnSave").click(function () {

		$.ajax({
			type: "GET",
			url: "/Home/GetSavedMobile",
			data: formData,

			success: function (data) {
				$("#txtName").val(data.Name);
				$("#txtCat").val(data.Catogery);
				$("#imgView").attr("src", "data:image/jpg;base64," + data.photo + "");
			},
			error: function (data) {
				console.log('Error:', data);
			}

		});


	});
	function RestFields() {
		$("#txtName", "#txtCat").val("");
		$("#imgView").attr("src", "");
	}


	});
	