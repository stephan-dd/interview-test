var rows = '<div class="row heroHeading">' +
                '<div class="col-md-2">name</div>' +
                '<div class="col-md-3">power</div>' +
                '<div class="col-md-2">stat(strength)</div>' +
                '<div class="col-md-2">stat(intelligence)</div>' +
                '<div class="col-md-2">stat(stamina)</div>' +
                '<div class="col-md-1"></div>' +
            '</div > ';
document.getElementById('heroesDiv').innerHTML = "<h1>Loading heroes. Please wait....</h1>";
$.ajax({
    url: "?handler=AllHeroes",
    success: function (result) {
        result.forEach(function (hero) {
            let random = Math.random() * 4;
            random = Math.floor(random);
            rows += '<div class="row hero' + random + '">' + 
                        '<div class="col-md-2">' + hero.name + '</div>' + 
                        '<div class="col-md-3">' + hero.power + '</div>' +
                        '<div class="col-md-2">' + hero.stats.find(s => s.key == "strength").value + '</div>' + 
                        '<div class="col-md-2">' + hero.stats.find(s => s.key == "intelligence").value + '</div>' + 
                        '<div class="col-md-2">' + hero.stats.find(s => s.key == "stamina").value + '</div>' +
                        '<div class="col-md-1"><a href="#" id="' + hero.name + '" class="btn btn-success" onclick="return evolve(\'' + hero.name + '\');">evolve</a></div>' + 
                    '</div > ';
        });
        document.getElementById('heroesDiv').innerHTML = rows;
    }
});
function evolve(heroName) {
    document.getElementById(heroName).innerHTML = "evolving...";
    document.getElementById(heroName).className = "btn btn-warning";
    $.ajax({
        url: "?handler=EvolveHero",
        type: "post",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: { "name": heroName, "action": "evolve" },
        success: function (result) {
            var hero = result;
            document.getElementById('heroStatsDiv').innerHTML = '<strong>' + hero.name + '</strong> updated with <strong>strength</strong>(' + result.stats.find(s => s.key == "strength").value +
                '), <strong>intelligence</strong>(' + result.stats.find(s => s.key == "intelligence").value +
                ') and <strong>stamina</strong> (' + result.stats.find(s => s.key == "stamina").value + ')';
            document.getElementById("heroStatsDiv").className = "alert alert-success";
            document.getElementById(heroName).innerHTML = "evolve";
            document.getElementById(heroName).className = "btn btn-success";
        }
    });
    return false;
}