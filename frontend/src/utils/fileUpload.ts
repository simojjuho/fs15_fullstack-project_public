import axios from "axios";

interface FileResponse {
    originalName: string
    filename: string
    location: string
}
const uploadFile = async (fileObject: {file: File}) => {
    const { data } = await axios.post<FileResponse>('https://api.escuelajs.co/api/v1/files/upload', fileObject, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      })
    return data
}

export default uploadFile

// [POST] https://api.escuelajs.co/api/v1/files/upload
// # Body
// {
//   "file": "<Binary File>"
// }

// The response is like this:

// {
//   "originalname": "Djhv7NO - Imgur.png",
//   "filename": "f3a5.png",
//   "location": "https://api.escuelajs.co/api/v1/files/f3a5.png"
// }