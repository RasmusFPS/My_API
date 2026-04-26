**Request** GET /api/User/Person 
``
  {
    "id": 1,
    "name": "Malte Andersson",
    "phone": "070-000-0000"
  },
``


**Request** GET /api/User/GetInterestById
https://localhost:7216/api/User/GetInterestById?PersonId=2
``
  {
    "name": "Max Granqvist",
    "interest": [
      {
        "title": "Gaming",
        "description": "Playing or Creating Games"
      }
    ]
  }
``

**Request** GET /api/User/GetLinksById
https://localhost:7216/api/User/GetLinksById?PersonId=2
``
{
  "name": "Max Granqvist",
  "link": [
    {
      "url": "https://steamcommunity.com/id/RasmusFPS/",
      "title": "Gaming",
      "description": "Playing or Creating Games"
    }
  ]
}
``
**Request** POST /api/User/AttachNewInterestById
https://localhost:7216/api/User/AttachNewInterestById?PersonId=3&InterestId=1
``
{
  "id": 19,
  "url": "",
  "interestId": 1,
  "personId": 3
}
``

POST /api/User/AddLinkById
https://localhost:7216/api/User/AddLinkById?PersonId=1
``
{
  "id": 20,
  "url": "www.Example.se",
  "interestId": 5,
  "personId": 1
}
``
