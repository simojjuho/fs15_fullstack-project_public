import { Box, Button, Input } from "@mui/material"

interface AmountInputProps {
    handleChange: (e: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>) => void
    handleUpdate: () => void
    initialValue: string | undefined
}
const AmountInput = ({ handleChange, handleUpdate, initialValue }: AmountInputProps) => {
  return (
    <Box sx={{
        display: 'flex',
        gap: 1
    }}>
        <Input color='secondary' type='number' onChange={handleChange} value={initialValue}/>
        <Button color="secondary" variant="outlined" onClick={handleUpdate}>Set</Button>
    </Box>
  )
}

export default AmountInput