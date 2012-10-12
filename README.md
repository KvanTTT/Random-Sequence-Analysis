Random-Sequence-Analysis
========================

A library for random sequences estimating with following criterions:

<ul>
<li><a href="http://en.wikipedia.org/wiki/Pearson%27s_chi-squared_test">Chi Square</a></li>
<li>Monte Carlo</li>
<li>Compression Ratio (using 7Zip with LZMA)</li>
<li>Extremium Criterion (russian description is <a href="http://www.machinelearning.ru/wiki/index.php?title=%D0%9A%D1%80%D0%B8%D1%82%D0%B5%D1%80%D0%B8%D0%B9_%D1%8D%D0%BA%D1%81%D1%82%D1%80%D0%B5%D0%BC%D1%83%D0%BC%D0%BE%D0%B2">here</a>, where is english decription I don't know :).</li>
</ul>

Mean and Variance are additional output parameters.

How to treat results:
<ul>
<li>White color: sequence random with high probability.</li>
<li>Yellow color: sequence may be not random.</li>
<li>Red color: sequence not random with high probability.</li>
</ul>

Combination of all criterions only show the most accurate picture of random sequence nature (but still it may be incorrect), not one criterion.

Sample screenshot:
<img src="http://imageshack.us/a/img717/464/randomsequenceanalysis.png" />

