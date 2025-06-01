package main

import (
	"fmt"
)

func subsets(nums []int) [][]int {
	res := [][]int{}
	subset := []int{}

	var dfs func(start int)
	dfs = func(i int) {
		if i >= len(nums) {
			temp := make([]int, len(subset))
			copy(temp, subset)
			res = append(res, temp)
			return
		}
		subset = append(subset, nums[i])
		dfs(i + 1)
		subset = subset[:len(subset)-1]
		dfs(i + 1)
	}

	dfs(0)
	return res

}

func subsets2(nums []int) [][]int {
	res := [][]int{{}}

	for _, num := range nums {
		n := len(res)
		for i := 0; i < n; i++ {
			newSubset := make([]int, len(res[i]))
			copy(newSubset, res[i])
			newSubset = append(newSubset, num)
			res = append(res, newSubset)
		}
	}

	return res
}

func main() {
	var nums = []int{1, 2, 3}
	var res = subsets2(nums)
	fmt.Println("Length:", len(res))
	fmt.Println("Subsets:", res)
}
