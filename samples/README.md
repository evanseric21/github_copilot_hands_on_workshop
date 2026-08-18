# Sample text note

`sample.txt` is original text written for this workshop. With token regex `[A-Za-z0-9]+`, invariant lowercase, no stop words, and ordering by count descending then `StringComparer.Ordinal` ascending ties, the expected top 5 are:

1. `tests: 5`
2. `build: 3`
3. `code: 3`
4. `copilot: 3`
5. `practice: 3`

`review` also appears 3 times and is excluded from the top 5 by the ordinal tie-break.
