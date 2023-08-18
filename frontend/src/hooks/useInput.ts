import { useState } from 'react'

const useInput = (initialValue: string = '') => {
    const [value, setValue] = useState(initialValue)
    const onChange = (e: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>
    ) => {
        setValue(e.target.value)
    }
    return { value, onChange }
}

export default useInput