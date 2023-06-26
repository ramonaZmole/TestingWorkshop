using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using TestingWorkshop.Helpers.Models.ApiModels;

namespace TestingWorkshop.Helpers;

public static class ApiHelpers
{
    public static string GetLoginToken(this RestClient client)
    {
        var output = client.CreateRequest(ApiResource.Login, new LoginInput(), Method.POST);
        return output.Cookies[0].Value;
    }

    public static CreateRoomOutput CreateRoom(this RestClient client)
    {
        var roomResponse = client.CreateRequest(ApiResource.Room, new CreateRoomInput(), Method.POST);
        return JsonConvert.DeserializeObject<CreateRoomOutput>(roomResponse.Content);
    }

    public static void CreateBooking(this RestClient client, CreateBookingInput createBookingInput)
    {
        createBookingInput.bookingdates.checkin = createBookingInput.bookingdates.checkin.Remove(8, 2).Insert(8, Constants.BookingStartDay);
        createBookingInput.bookingdates.checkout = createBookingInput.bookingdates.checkout.Remove(8, 2).Insert(8, Constants.BookingEndDay);
        client.CreateRequest(ApiResource.Booking, createBookingInput, Method.POST);
    }

    public static void DeleteRoom(this RestClient client, string roomName)
    {
        var roomsList = client.GetRooms();
        if (roomsList == null) return;

        var roomId = roomsList.rooms.First(x => x.roomName == int.Parse(roomName)).roomid;
        client.CreateRequest($"{ApiResource.Room}{roomId}", Method.DELETE);
    }

    public static void DeleteRoom(this RestClient client, int roomId)
    {
        var t = client.CreateRequest($"{ApiResource.Room}{roomId}", Method.DELETE);
    }

    private static GetRoomsOutput GetRooms(this RestClient client)
    {
        var response = client.CreateRequest(ApiResource.Room);
        return JsonConvert.DeserializeObject<GetRoomsOutput>(response.Content);
    }
}