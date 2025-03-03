PGDMP     "    7                {         
   homework_2    15.4    15.3     6           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            7           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            8           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            9           1262    16390 
   homework_2    DATABASE     �   CREATE DATABASE homework_2 WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = icu LOCALE = 'en_US.UTF-8' ICU_LOCALE = 'en-US';
    DROP DATABASE homework_2;
                postgres    false            �            1259    16394    departments    TABLE       CREATE TABLE public.departments (
    department_name character varying(100),
    faculty character varying(100),
    manager_full_name character varying(100),
    room_number integer,
    building_number integer,
    phone_number bigint,
    teacher_count integer
);
    DROP TABLE public.departments;
       public         heap    postgres    false            �            1259    16391 	   faculties    TABLE     �   CREATE TABLE public.faculties (
    faculty_name character varying(100),
    dean_fio character varying(100),
    room_number integer,
    building_number integer,
    phone_number bigint
);
    DROP TABLE public.faculties;
       public         heap    postgres    false            �            1259    16405    progress    TABLE     �   CREATE TABLE public.progress (
    group_number integer,
    student_id integer,
    subject character varying(100),
    mark integer
);
    DROP TABLE public.progress;
       public         heap    postgres    false            �            1259    16400    students    TABLE     W  CREATE TABLE public.students (
    student_id integer,
    student_surname character varying(100),
    student_name character varying(100),
    student_patronymic character varying(100),
    group_number integer,
    gender character varying(10),
    address character varying(100),
    city character varying(100),
    phone_number bigint
);
    DROP TABLE public.students;
       public         heap    postgres    false            �            1259    16397    study_groups    TABLE     �   CREATE TABLE public.study_groups (
    department_name character varying(100),
    group_number integer,
    admission_year integer,
    study_course integer,
    students_number integer
);
     DROP TABLE public.study_groups;
       public         heap    postgres    false            0          0    16394    departments 
   TABLE DATA           �   COPY public.departments (department_name, faculty, manager_full_name, room_number, building_number, phone_number, teacher_count) FROM stdin;
    public          postgres    false    215   �       /          0    16391 	   faculties 
   TABLE DATA           g   COPY public.faculties (faculty_name, dean_fio, room_number, building_number, phone_number) FROM stdin;
    public          postgres    false    214   �       3          0    16405    progress 
   TABLE DATA           K   COPY public.progress (group_number, student_id, subject, mark) FROM stdin;
    public          postgres    false    218   b       2          0    16400    students 
   TABLE DATA           �   COPY public.students (student_id, student_surname, student_name, student_patronymic, group_number, gender, address, city, phone_number) FROM stdin;
    public          postgres    false    217   c       1          0    16397    study_groups 
   TABLE DATA           t   COPY public.study_groups (department_name, group_number, admission_year, study_course, students_number) FROM stdin;
    public          postgres    false    216   6!       �           2606    16432    study_groups uk_group_number 
   CONSTRAINT     _   ALTER TABLE ONLY public.study_groups
    ADD CONSTRAINT uk_group_number UNIQUE (group_number);
 F   ALTER TABLE ONLY public.study_groups DROP CONSTRAINT uk_group_number;
       public            postgres    false    216            �           2606    16444    students uk_srtudent_id 
   CONSTRAINT     X   ALTER TABLE ONLY public.students
    ADD CONSTRAINT uk_srtudent_id UNIQUE (student_id);
 A   ALTER TABLE ONLY public.students DROP CONSTRAINT uk_srtudent_id;
       public            postgres    false    217            �           2606    16425 "   departments unique_department_name 
   CONSTRAINT     h   ALTER TABLE ONLY public.departments
    ADD CONSTRAINT unique_department_name UNIQUE (department_name);
 L   ALTER TABLE ONLY public.departments DROP CONSTRAINT unique_department_name;
       public            postgres    false    215            �           2606    16418    faculties unique_faculty_name 
   CONSTRAINT     `   ALTER TABLE ONLY public.faculties
    ADD CONSTRAINT unique_faculty_name UNIQUE (faculty_name);
 G   ALTER TABLE ONLY public.faculties DROP CONSTRAINT unique_faculty_name;
       public            postgres    false    214            �           2606    16419 !   departments fk_department_faculty    FK CONSTRAINT     �   ALTER TABLE ONLY public.departments
    ADD CONSTRAINT fk_department_faculty FOREIGN KEY (faculty) REFERENCES public.faculties(faculty_name);
 K   ALTER TABLE ONLY public.departments DROP CONSTRAINT fk_department_faculty;
       public          postgres    false    214    3477    215            �           2606    16426    study_groups fk_department_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.study_groups
    ADD CONSTRAINT fk_department_id FOREIGN KEY (department_name) REFERENCES public.departments(department_name);
 G   ALTER TABLE ONLY public.study_groups DROP CONSTRAINT fk_department_id;
       public          postgres    false    215    216    3479            �           2606    16433    students fk_group_number    FK CONSTRAINT     �   ALTER TABLE ONLY public.students
    ADD CONSTRAINT fk_group_number FOREIGN KEY (group_number) REFERENCES public.study_groups(group_number);
 B   ALTER TABLE ONLY public.students DROP CONSTRAINT fk_group_number;
       public          postgres    false    216    3481    217            �           2606    16438    progress fk_group_number    FK CONSTRAINT     �   ALTER TABLE ONLY public.progress
    ADD CONSTRAINT fk_group_number FOREIGN KEY (group_number) REFERENCES public.study_groups(group_number);
 B   ALTER TABLE ONLY public.progress DROP CONSTRAINT fk_group_number;
       public          postgres    false    216    218    3481            �           2606    16445    progress fk_student_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.progress
    ADD CONSTRAINT fk_student_id FOREIGN KEY (student_id) REFERENCES public.students(student_id);
 @   ALTER TABLE ONLY public.progress DROP CONSTRAINT fk_student_id;
       public          postgres    false    3483    218    217            0   �   x�E�Kn� D��)8�e�/;��ƀؒ�����Jv�jUի�JM�����Q
!��
Љ1�a,Hx�bzH��0�}�
�ҍ!m�f^�R}(p?��=���3f��PҀa)�0���B�"nܭ>4������t"?M# �C#��h1�bޥ��ͳ��R���G|7�<�۞Q�苴�Z
=���S�,`m�X�m�'}��a�&5�f�4�c�&�LL      /   �   x�=�K�  ��p
O@��@e��������CP�����KL�p�)��.+��@p�Fb�#��?r�2챆�)'�b���j-&?o��nW�
���a���)�q��屺�\ �"@�K��\i�+�zw�fg�`@���b�ƈ�B��-[      3   �   x�u�M� ��x���#�ߥu�:SKG����	Ҹ�|$�'sR�Y��^��2��[Q$�^�I-�*r+t����M�����:;�J=L��ig�a8�Y*E��䴏^��v�|�;c����G�JG�M�i�2"ˀ�)��*:~Z:�N?�D�����1:�+�=K�5�}��ml��B�'�E+�1
��(q�g��B�;��Y�p�!�pY�o��p��|o+��F��W���&I�����      2   �  x���]��0���Sp�ъ����M,b)���9�L��d�!�uUu ��!2�|�ORzׅ[ȩ�����zO���g����D���XВ3�QF��%<9#	����r��9R�5��F��98RB�*wp3跟Q��7ׇf����G#7��Bq�@�L�wJ9�$\R^$����	R�Y�q(�8�K����5�,�.����H�NSENhk��p,���xu��V�j�?��;B*Ƹ�����"�¨��5�v��|����m��R�k!�S3�K5�!�09rw�O?��%�0���v��lo������7�v޴b��b�n�����9֚�O��1ï�qق`��ˌ�B�p{�U�$�Ӥ�,F�~��!��?��=��{.$���*���U���ھ��q}Za�%>�����5~��dU�ʾĵl�{�C\��_��_���WA      1   �   x�5�A
�0��+��ہ�G��� �����;j��=vG��ة�9}�z�I?GS�`������<��t��:kvr����芨����Keu�W!)iw�q������"���h�UU׋N�҉eP�����5�x���ߎ�7D� �)�     