# DocuSignDemo
Demo project for DocuSign



## **Problem Description**

**Problem:**

You are in your house wearing pajamas. You must be appropriately dressed for the temperature before leaving your house.

Your challenge is to programmatically process a list of commands for getting ready, enforce related rules, and display appropriate output.

**Inputs:**

1. 1.Temperature Type (one of the following)
  - HOT
  - COLD
2. 2.Comma separated list of numeric commands

| Command | Description | HOT Response | COLD Response |
| --- | --- | --- | --- |
| 1 | Put on footwear | "sandals" | "boots" |
| 2 | Put on headwear | "sun visor" | "hat" |
| 3 | Put on socks | fail | "socks" |
| 4 | Put on shirt | "t-shirt" | "shirt" |
| 5 | Put on jacket | fail | "jacket" |
| 6 | Put on pants | "shorts" | "pants" |
| 7 | Leave house | "leaving house" | "leaving house" |
| 8 | Take off pajamas | "Removing PJs" | "Removing PJs" |

**Rules:**

- Initial state is in your house with your pajamas on
- Pajamas must be taken off before anything else can be put on
- Only 1 piece of each type of clothing may be put on
- You cannot put on socks when it is hot
- You cannot put on a jacket when it is hot
- Socks must be put on before shoes
- Pants must be put on before shoes
- The shirt must be put on before the headwear or jacket
- You cannot leave the house until all items of clothing are on (except socks and a jacket when it's hot)
- If an invalid command is issued, respond with "fail" and stop processing commands

## **Examples**

**Success**

Input: HOT 8, 6, 4, 2, 1, 7
Output: Removing PJs, shorts, t-shirt, sun visor, sandals, leaving house

Input: COLD 8, 6, 3, 4, 2, 5, 1, 7
Output: Removing PJs, pants, socks, shirt, hat, jacket, boots, leaving house

**Failure**

Input: HOT 8, 6, 6
Output: Removing PJs, shorts, fail

Input: HOT 8, 6, 3
Output: Removing PJs, shorts, fail

Input: COLD 8, 6, 3, 4, 2, 5, 7
Output: Removing PJs, pants, socks, shirt, hat, jacket, fail

Input: COLD 6
Output: fail

### **Solution**
A test driven development approach was taken where tests were written for all core functionality. Business rules were clubed together
if possible and converted into functions with corresponding tests. Each function would return the index of the rule violating variable. If all variables were found to be following the business rule a flag of `-1` was sent back. Once we got back all the indices
and flags from the Busines rule functions we would print the entire Input set if the all functions returned `-1`.

However depending upon the number of Business rules violated we would get back multiple indices. We would then sort them to find the 
lowest positive number and print the input set till that number before exiting. 

### **Results**
The program has been tested successfully on all the Example input sets provided in the requirements spec. The program is open ended in nature 
allowing for modification of business rules with ease. The program can also be easily extended to mention the rule/rules violated as we have stored all violations in an array.
