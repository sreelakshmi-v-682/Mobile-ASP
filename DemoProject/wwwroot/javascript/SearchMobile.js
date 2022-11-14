$(document).ready(function () {
    $("#mobileName").keyup(function () {
        var name = $("#mobileName").val();


        $.ajax(

            {
                url: "/Home/Search",
                type: "Get",
                dataType: "JSON",
                contentType: "application/json",
                data: { "mobileName": name },

                success: function (data) {
                    if (data == null) {
                        alert("Oops Some Internal Error");
                    }
                    else {
                        if (data.length == 0) {
                            document.getElementById("card-group").innerHTML = "";
                            document.getElementById("error-msg").innerText = "Oops ! No Results Found";

                        }
                        else {
                            document.getElementById("error-msg").innerHTML = "";
                            document.getElementById("card-group").innerHTML = "";
                            $.each(data, function (items) {
                                var photoPath = "/images/" + data[items].photoPath;
                                var mob = "<div class='col-sm-6 col-md-4'> <div class='card mb-5 card-hov  card-shadow'> <div class='card-body' > <img src='" + photoPath + "' class='img-fluid mt-2' asp-append-version='true' > <h4 class='mt-2 mb-2'>" + data[items].courseName + "</h4> <p class='mt-2'>" + data[items].courseDescription + "</p> </div> <div class='card-footer text-center'><a href='/User/Login' class = 'link-text' >Learn for Free</a> </div> </div> </div>";
                                $("#card-group").append(mob);
                            });
                        }
                    }
                },
                error: function () {
                    alert("Data Not Found");
                }
            }
        );


    });


});

11: 33
