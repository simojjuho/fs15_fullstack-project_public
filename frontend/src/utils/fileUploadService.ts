import uploadFile from "./fileUpload"

/**
 * @asyncs
 */
const fileUploadService = (images: { file: File }[]) => {
    const fileData = Promise.all(images.map(async file => {
        const fileResponse = await uploadFile(file)
        return fileResponse.location
    }))
    return fileData
}

export default fileUploadService