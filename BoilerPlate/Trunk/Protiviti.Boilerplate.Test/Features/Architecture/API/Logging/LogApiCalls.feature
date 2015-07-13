Feature: Log API Calls
	In order to debug and trouble shoot the application
	As a developer
	I want the system to log all api calls when a special configuration flag is set 

	@Hanna
Scenario: Logging Turned Off
	Given I have set the api logging level to "none"
	When I make a request to the api
	Then the request should not be logged to the database
  | Property Name      | Property Type | Description                                                      |
  | Date               | Date          | Null                                                             |
  | OriginatingIP      | String        | Null                                                             |
  | ServerName         | String        | Null                                                             |
  | ServerIP           | String        | Null                                                             |
  | UserId             | String        | Null                                                             |
  | RequestURL         | String        | Null                                                             |
  | RequestPath        | String        | Null                                                             |
  | RequestQueryString | String        | Null                                                             |
  | RequestBody        | String        | Null                                                             |
  | RequestHeaders     | String        | Null                                                             |
  | RequestSize        | Number        | Null                                                             |
  | ResponseDuration   | Number        | Null                                                             |
  | ResponseCode       | String        | Null                                                             |
  | ResponseBody       | String        | Null                                                             |
  | ResponseHeaders    | String        | Null                                                             |
  | ResponseSize       | Number        | Null                                                             |

Scenario: Logging Turned On
	Given I have set the api logging level to "all"
	When I make a request to the api
	Then the request should be logged to the database with the following properties
  | Property Name      | Property Type | Description                                                      |
  | Date               | Date          | The date the request was made.                                   |
  | OriginatingIP      | String        | The IP address the request came from.                            |
  | ServerName         | String        | The name of the server that got the request.                     |
  | ServerIP           | String        | The ip address of the server that received the request.          |
  | UserId             | String        | The id of the user that issued the request.                      |
  | RequestURL         | String        | The full URL of the request.                                     |
  | RequestPath        | String        | The path of the request. Url minus domain and request paramters. |
  | RequestQueryString | String        | The query string of the URL.                                     |
  | RequestBody        | String        | Serialized body of the request.                                  |
  | RequestHeaders     | String        | Serialized array of the request headers.                         |
  | RequestSize        | Number        | The size in bytes for the total request.                         |
  | ResponseDuration   | Number        | The number of miliseconds from the request to the response.      |
  | ResponseCode       | String        | The http status code of the reponse.                             |
  | ResponseBody       | String        | Serialized body of the response.                                 |
  | ResponseHeaders    | String        | Serialized array of the response headers.                        |
  | ResponseSize       | Number        | The size bytes for the total response.                           |

