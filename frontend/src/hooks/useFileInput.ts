import { useState } from "react"

const useFileInput = () => {
    const [file, setFile] = useState<FileList>()
    const onChange = (e: React.ChangeEvent<HTMLInputElement>
        ) => {
            const { files } = e.target
            if(files) {
                setFile(files)
            }
    }
    return {file, onChange, setFile}
}

export default useFileInput