import { useState, useEffect } from 'react'

const useDebounce = <T>(
    callBack: (filter: string, items: T[]) => T[],
    items: T[] | undefined
) => {
  const [search, setSearch] = useState<string>('')
  const [filteredItems, setFilteredItems] = useState<T[]>([])
  useEffect(() => {
    if(items) {
        const timeoutId = setTimeout(() => {
            setFilteredItems(callBack(search, items))
        }, 1000)
        return () => clearTimeout(timeoutId)        
    }
  }, [search, items, callBack])
  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    setSearch(e.target.value)
  }
  return { search, handleChange, filteredItems}
}

export default useDebounce