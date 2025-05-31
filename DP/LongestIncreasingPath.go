package main

import (
	"fmt"
)

func longestIncreasingPath(matrix [][]int) int {
	rows, columns := len(matrix), len(matrix[0])
	directions := [][]int{{-1, 0}, {1, 0}, {0, -1}, {0, -1}, {0, 1}}

	var dfs func(r, c, previousValue int) int
	dfs = func(r, c, previousValue int) int {
		if r < 0 || r >= rows || c < 0 || c >= columns || matrix[r][c] <= previousValue {
			return 0
		}
		res := 1
		for _, d := range directions {
			res = max(res, 1+dfs(r+d[0], c+d[1], matrix[r][c]))
		}

		return res
	}

	lip := 0
	for r := 0; r < rows; r++ {
		for c := 0; c < columns; c++ {
			lip = max(lip, dfs(r, c, -1<<31))
		}
	}
	return lip
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}

func longestIncreasingPath2(matrix [][]int) int {
	rows, columns := len(matrix), len(matrix[0])
	dp := make([][]int, rows)
	for i := range dp {
		dp[i] = make([]int, columns)
	}

	var dfs2 func(r, c, previousValue int) int
	dfs2 = func(r, c, previousValue int) int {
		if r < 0 || r >= rows || c < 0 || c >= columns || matrix[r][c] <= previousValue {
			return 0
		}

		if dp[r][c] != 0 {
			return dp[r][c]
		}

		res := 1
		res = max(res, 1+dfs2(r+1, c, matrix[r][c]))
		res = max(res, 1+dfs2(r-1, c, matrix[r][c]))
		res = max(res, 1+dfs2(r, c+1, matrix[r][c]))
		res = max(res, 1+dfs2(r, c-1, matrix[r][c]))

		dp[r][c] = res
		return res
	}

	maxPath := 0
	for r := 0; r < rows; r++ {
		for c := 0; c < columns; c++ {
			maxPath = max(maxPath, dfs2(r, c, -1))
		}
	}

	return maxPath

}

func longestIncreasingPath3(matrix [][]int) int {
	rows, columns := len(matrix), len(matrix[0])
	indegree := make([][]int, rows)
	for i := range indegree {
		indegree[i] = make([]int, columns)
	}

	directions := [][]int{{-1, 0}, {1, 0}, {0, -1}, {0, 1}}

	for r := 0; r < rows; r++ {
		for c := 0; c < columns; c++ {
			for _, d := range directions {
				nr, nc := r+d[0], c+d[1]
				if nr >= 0 && nr < rows && nc >= 0 && nc < columns && matrix[nr][nc] < matrix[r][c] {
					indegree[r][c]++
				}
			}
		}
	}

	queue := [][]int{}
	for r := 0; r < rows; r++ {
		for c := 0; c < columns; c++ {
			if indegree[r][c] == 0 {
				queue = append(queue, []int{r, c})
			}
		}
	}

	lis := 0
	for len(queue) > 0 {
		size := len(queue)
		for i := 0; i < size; i++ {

			node := queue[0]
			queue = queue[1:]
			r, c := node[0], node[1]
			for _, d := range directions {
				nr, nc := r+d[0], c+d[1]
				if nr >= 0 && nr < rows && nc >= 0 && nc < columns && matrix[nr][nc] > matrix[r][c] {
					indegree[nr][nc]--
					if indegree[nr][nc] == 0 {
						queue = append(queue, []int{nr, nc})
					}
				}
			}
		}
		lis++
	}
	return lis
}

func main() {
	matrix := [][]int{{1, 2, 3}, {2, 1, 4}, {7, 6, 5}}
	fmt.Println(longestIncreasingPath3(matrix))
}
