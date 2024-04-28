# Intuition
Given a connected tree with n nodes, the goal is to compute the sum of distances between a given node and all other nodes in the tree for each node in the tree. The direct approach of computing the distances between each pair of nodes would be inefficient. Instead, we can use a two-phase approach that leverages the tree structure:

Calculate the sum of distances from a chosen root node (e.g., node 0) to all other nodes using a depth-first search (DFS). This will also calculate the size of the subtree rooted at each node.
Use the results from the first phase to compute the sum of distances for the other nodes efficiently.
The adjacency list representation of the tree allows for easy traversal and efficient computation of distances and subtree sizes.

# Approach
1. Phase 1: We start from a specific root node (e.g., node 0) and perform a DFS to calculate the sum of distances (distSum) from the root node to all other nodes. This also calculates the size of each subtree (subtreeSize) rooted at each node during traversal. This information is gathered using recursion and the adjacency list representation of the tree.
   
2. Phase 2: Using the information from the first phase, we calculate the sum of distances for each node. Starting again from the root node, we iterate through all adjacent nodes and adjust the sum of distances based on the distances calculated in the first phase.  This formula efficiently recalculates the sum of distances for each node without needing to repeat the traversal process from each node.
   
3. The results from the two phases provide the sum of distances for each node, which can be returned as the final answer.
# Complexity
- Time complexity: The time complexity of the approach is O(n). Both phases consist of traversals through the tree, which is done in linear time since each node and edge is visited once.
- Space complexity: The space complexity is also O(n). The main storage requirements come from the adjacency list representation of the tree and the arrays for distSum and subtree size, all of which require space proportional to the number of nodes.
