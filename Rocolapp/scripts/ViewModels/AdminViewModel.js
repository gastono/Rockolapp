var AdminViewModel = function ()
{
    var self = this;

    self.ScreenList = ko.observableArray();
    self.ScreenNumber = ko.observable();
    self.SpotifyUserId = ko.observable();

    self.AddScreen = function ()
    {

        var request = new NewScreen();
        request.ScreenCode(self.ScreenNumber());
        request.SpotifyUserId(self.SpotifyUserId());


        $.ajax({
            url: "http://localhost:58785/api/ScreenApi/Register",
            type: 'POST',
            data: request,
            success: function (data) {

                var addedScreen = new NewScreen();
                addedScreen.ScreenCode(self.ScreenCode());
                self.ScreenList.push(addedScreen);

                $('#addscreen-Modal').modal('hide');

            }
        });
    }

    
}

var NewScreen = function ()
{
    var self = this;

    self.Id = ko.observable();
    self.UserName = ko.observable();
    self.RocolappUserName = ko.observable();
    self.SpotifyUserId = ko.observable();
    self.ConnectionId = ko.observable();
    self.Connected = ko.observable();
    self.ScreenCode = ko.observable(); 
}