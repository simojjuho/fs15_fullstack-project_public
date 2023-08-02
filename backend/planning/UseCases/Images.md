# Product and category images use cases

## Adding an image
1. Receiving a POST request to the image endpoint with an image binary file in the body.
   - Role based authorization in use, 'admin' role required
2. ImageController
3. -> ImageService
4. -> ImageFileHandler
    - Saves the images and gives them new names
    - Returns an ImageLocation instance, that has the url for the image and image file name.
5. -> ImageService
6. -> ImageRepository
   - Saves the image location in the database
7. If successful a status code 200 is sent to as a response along with an object with the image image url and file_name


## Removing an image
This is optional, not yet planning.