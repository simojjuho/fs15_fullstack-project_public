# User Use Cases from Backend Point of view

## Creating a user

1. Registration POST request comes to the api end point localhost:[PORT]/api/v1/users
   - It has the information consisting user names, email, password.
2. UserController.CreateUser calls UserService.CreateUser and passes the UserDTO to the user service.
   - UserService.CreateUser uses Mapper to torn the userDto into a User instance
   - Turns the password into binary form
   - user id is created
3. UserService.CreateUser calls UserRepository.CreateUser
   - Adds the user to _users and saves changes.
4. When user is created, the user can log in using the credentials. The process informs user with a status code of 201 if succesful.

## Updating a user (EXTRA)

1. PATCH request comes to the API endpoint localhost:[PORT]/api/v1/users
   - It has the information consisting user names, email, password.
2. Checking the token in UserController, id must match with the user that will be updated.
3. UserController.UpdateUser calls UserService.CreateUser and passes the UserDTO to the user service.
   - UserService.UpdateUser uses Mapper to torn the userDto into a User instance
   - Turns the password into binary form
4. UserService.UpdateUser calls UserRepository.UpdateUser
   - Update the user in _users and saves changes.
5. The process informs user with a status code of 200 and the updated user if succesful.

## Remove a user (EXTRA)

1. DELETE request comes to API endpoint localhost:[PORT]/api/v1/users
2. Checking the id from token. in the UserController. Id must match with the user that will be removed.
3. 3UserController -> UserService -> UserRepository -> RemoveUser with id.
4. Response with a status code 204 if successful.

## Get user by id (EXTRA)

1. Get one user by id
2. 3UserController -> UserService -> UserRepository -> GetUserById
3. Response with status code 200 with the entity if successful

