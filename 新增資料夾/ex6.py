def TwoSum (nums, target):
    answer = []
    for i in range(len(nums)):
        for j in range(i):
            if nums[i] + nums[j] == target:
                answer.append(j)
                answer.append(i)
    return answer

target = int(input("enter your target number: "))

nums = []
n = 0

while n == 0:    
    try:
        num = int(input("enter numbers, press other keys to leave: "))
        nums.append(num)
    except ValueError:
        break;

print ("answer is : ", TwoSum(nums, target))