الفرق بين Class وStruct وRecord
Class: بنستخدمه عشان نجمع بيانات ودوال في نوع واحد. هو Reference Type، يعني لو عملت s2 = s1، الاتنين بيشاوروا على نفس الـObject.
Struct: هو Value Type، يعني لما بساوي متغير بمتغير تاني، بتتنسخ القيمة. زي نقطة فيها X وY.
Record: مناسب لتخزين البيانات، وبيوفّر مقارنة تلقائية حسب القيم. هو Reference Type افتراضيًا، لكن لو كتبت record struct بيبقى Value Type.

2. يعني إيه Indexer؟
الـIndexer بيخليني أتعامل مع الـObject باستخدام [] زي الـArray، مثلًا students[0]. بنعرّفه بكلمة this، وبنستخدم get للقراءة وset للتعديل.
