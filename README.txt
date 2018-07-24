## Build
Open solution in visual studio and click run (make sure external packages are installed on build)

### Assumption
We assume the job skills are listed from more important to less important.

### Logic 
Using the skills required for each jobs and the skills of each candidates we'll calculate some fitness values for each candidate.
We use them in order to evaluate wich candidate is the best suited for the job, here they are listed from more important to less important:
1. Number of skill matching
2. Skill Weight
3. Index of first match

#### Tie Breaker logic
##### Number of skill matching
The candidate with the highest number of matching skills is the fittest.

##### Skill Weight
In case of a tie on the previous tie breaker, since the skills on the jobs are listed by order of importance, it is better to have skills listed early.
Each skill of the jobs is given a weight equal to its index in the list, the sum of the matching indexes is the skill weight between a job and a candidate.
The lower the weight the better.

ex:
Given a job with skills: C#, react, jquery, entity framework
A candidate with (only) C# and react is fitter than a candidate with (only) jquery and entity framework.

##### First matching Skill
In case of a tie in the previous tie breaker, then the candidate with the smaller Index of first match is fitter.