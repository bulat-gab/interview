def isPalindrome(s: str) -> bool:
        if not s:
            return True
        
        n = len(s)
        start = 0
        end = n - 1
        
        while start < end:
            while start < n and not s[start].isalpha():
                start += 1
                
            while end > -1 and not s[end].isalpha():
                end -= 1
            
            if start < n and end > -1:
                return True
                
            if start < n and end > -1 and s[start].lower() == s[end].lower():
                start += 1
                end -= 1
                continue
            else:
                return False
            
        return True


isPalindrome(".,")